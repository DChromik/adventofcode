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

let resolvePart2 (lines: seq<string>) : int = 0
