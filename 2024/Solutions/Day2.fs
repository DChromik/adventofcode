module Day2

let parseLine (line: string) : int[] = line.Split(' ') |> Array.map int

let areOrdered (pairs: seq<int * int>) : bool =
    Seq.forall (fun (a, b) -> a > b) pairs || Seq.forall (fun (a, b) -> a < b) pairs

let isWithinThreshold (pairs: seq<int * int>) (threshold: int) : bool =
    Seq.forall (fun (a, b) -> abs (a - b) <= threshold) pairs

let isSafe (levels: seq<int>) : bool =
    let pairedLevels = Seq.pairwise levels

    areOrdered pairedLevels && isWithinThreshold pairedLevels 3

let resolvePart1 (lines: seq<string>) =
    lines |> Seq.map parseLine |> Seq.filter isSafe |> Seq.length

let isSafeWithDampening (levels: seq<int>) : bool =
    if isSafe levels then
        true
    else
        levels
        |> Seq.mapi (fun idx _ -> levels |> Seq.indexed |> Seq.filter (fun (i, _) -> i <> idx) |> Seq.map snd)
        |> Seq.exists isSafe

let resolvePart2 (lines: seq<string>) =
    lines |> Seq.map parseLine |> Seq.filter isSafeWithDampening |> Seq.length
