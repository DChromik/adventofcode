module Day2

let parseLine (line: string) : int[] = line.Split(' ') |> Array.map int

let areOrdered (pairs: seq<int * int>) : bool =
    Seq.forall (fun (a, b) -> a > b) pairs || Seq.forall (fun (a, b) -> a < b) pairs

let isWithinThreshold (pairs: seq<int * int>) (threshold: int) : bool =
    Seq.forall (fun (a, b) -> abs (a - b) <= threshold) pairs

let isReportSafe (levels: seq<int>) : bool =
    let pairedLevels = Seq.pairwise levels

    areOrdered pairedLevels && isWithinThreshold pairedLevels 3

let resolvePart1 (lines: seq<string>) =
    lines |> Seq.map parseLine |> Seq.filter isReportSafe |> Seq.length

let resolvePart2 (lines: seq<string>) = 0
