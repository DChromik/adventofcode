module Day9

let isEven (n: int64) = n % 2L = 0L

type Block =
    | ID of int64
    | Empty

type Space =
    | File of int64 * int64
    | EmptySpace of int64

let stringToIntArray (s: string) =
    s.Trim().ToCharArray() |> Array.map (fun c -> c.ToString() |> int)

let indexToBlock (i: int64) = if isEven i then ID(i / 2L) else Empty

let indexToFile index size =
    if isEven index then
        File(index / 2L, size)
    else
        EmptySpace size

let parseInput (lines: seq<string>) =
    lines
    |> Seq.head
    |> stringToIntArray
    |> Array.indexed
    |> Array.map (fun (i, n) -> indexToBlock i |> Array.create n)
    |> Array.reduce Array.append

let getLastBlock (storage: (int * Block)[]) (index: int) =
    storage
    |> Array.find (fun (i, b) ->
        if i >= index then
            false
        else
            match b with
            | ID _ -> true
            | Empty -> false)


let defragmentStorage (storage: Block[]) =
    let mutable reverseIndex = storage.Length
    let reversedStorage = storage |> Array.indexed |> Array.rev

    storage
    |> Array.mapi (fun index block ->
        if index >= reverseIndex then
            Empty
        else
            match block with
            | ID _ -> block
            | Empty ->
                let (i, b) = getLastBlock reversedStorage reverseIndex
                reverseIndex <- i
                b)

let resolvePart1 (lines: seq<string>) =
    lines
    |> parseInput
    |> defragmentStorage
    |> Array.indexed
    |> Array.map (fun (index, c) ->
        match c with
        | ID(x) -> int64 index * x
        | Empty -> 0L)
    |> Array.sum

let stringToFiles (s: string) =
    s.Trim().ToCharArray()
    |> Array.indexed
    |> Array.map (fun (i, c) -> indexToFile i (c.ToString() |> int64))

let swap (arr: Space[]) (file: int * Space) (space: int * Space) =
    let swapped = arr |> Array.insertAt (fst space) (snd file)

    match (snd file, snd space) with
    | (File(_, fSize), EmptySpace size) -> Array.set swapped (fst file) (EmptySpace(size - fSize))
    | __ -> ()

    Array.set swapped (fst file) (snd space)

    swapped

let defragmentByFile (storage: Space[]) : Space[] =
    let indexedStorage = storage |> Array.indexed

    Array.foldBack
        (fun (fileIndex, file) defragmented ->
            match file with
            | EmptySpace _ -> defragmented
            | File(_, fileSize) ->
                let spaceIndex =
                    defragmented
                    |> Array.tryFindIndex (fun block ->
                        match block with
                        | EmptySpace size -> fileSize <= size
                        | File _ -> false)

                match spaceIndex with
                | None -> defragmented
                | Some spaceIndex -> swap defragmented (fileIndex, file) (spaceIndex, defragmented[spaceIndex]))
        indexedStorage
        storage

let resolvePart2 (lines: seq<string>) : int =
    let files = lines |> Seq.head |> stringToFiles

    let defragmented = defragmentByFile files
    printfn "%A" files
    printfn "%A" defragmented

    0
