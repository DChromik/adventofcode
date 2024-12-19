module Day9

let isEven (n: int64) = n % 2L = 0L

type Block =
    | ID of int64
    | Empty

let stringToIntArray (s: string) =
    s.Trim().ToCharArray() |> Array.map (fun c -> c.ToString() |> int)

let indexToBlock (i: int64) = if isEven i then ID(i / 2L) else Empty

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

let swapFile (storage: Block[]) (size: int) (fileIndex: int) (spaceIndex: int) =
    for i = 0 to (size - 1) do
        let tmp = storage[fileIndex + i]

        storage[fileIndex + i] <- storage[spaceIndex + i]
        storage[spaceIndex + i] <- tmp

let defragmentStorageByFile (storage: Block[]) =
    let sizes = storage |> Array.groupBy id

    for index = storage.Length - 1 downto 0 do
        printfn "Files remaining: %A" index

        let id = storage[index]

        let size =
            match id with
            | ID id ->
                sizes
                |> Array.find (fun (block, count) ->
                    match block with
                    | ID bid when bid = id -> true
                    | _ -> false)
                |> snd
                |> Array.length
            | _ -> 0

        if size > 0 then
            let spaceIndex =
                storage
                |> Array.take index
                |> Array.windowed size
                |> Array.tryFindIndex (fun window ->
                    window
                    |> Array.forall (fun block ->
                        match block with
                        | Empty -> true
                        | _ -> false))

            match spaceIndex with
            | Some spaceI when spaceI < index -> swapFile storage size (index - size + 1) spaceI
            | _ -> ()

    storage

let resolvePart2 (lines: seq<string>) =
    lines
    |> parseInput
    |> defragmentStorageByFile
    |> Array.indexed
    |> Array.map (fun (index, c) ->
        match c with
        | ID(x) -> int64 index * x
        | Empty -> 0L)
    |> Array.sum
