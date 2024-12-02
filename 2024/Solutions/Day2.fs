module Day2

let parseLine (line: string) = line.Split([| ' ' |]) |> Array.map int

let areOrdered (levels: seq<int * int>) =
    Seq.forall (fun (a, b) -> a > b) levels
    || Seq.forall (fun (a, b) -> a < b) levels

let isReportSafe (levels: seq<int>) =
    let pairedLevels = Seq.pairwise levels

    areOrdered pairedLevels
    && Seq.forall (fun (a, b) -> abs (a - b) <= 3) pairedLevels

let resolvePart1 (lines: seq<string>) =
    Seq.map parseLine lines
    |> Seq.fold (fun acc current -> acc + if isReportSafe current then 1 else 0) 0

let resolvePart2 (lines: seq<string>) = 0
