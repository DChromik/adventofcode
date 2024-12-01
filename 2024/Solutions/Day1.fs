module Day1

let distance (a: int, b: int) = a - b |> abs

let getSimilarity (score: option<int>) =
    match score with
    | Some(x) -> x
    | None -> 0

let parseLine (line: string) =
    line.Split([| ' ' |], System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.map int

let resolvePart1 (lines: seq<string>) =
    let result =
        lines
        |> Seq.map parseLine
        |> Seq.toArray
        |> Array.transpose
        |> Array.map Array.sort

    Array.zip result[0] result[1] |> Array.map distance |> Array.sum

let resolvePart2 (lines: seq<string>) =
    let columns = lines |> Seq.map parseLine |> Seq.toArray |> Array.transpose

    let counts = columns[1] |> Array.countBy id |> Map.ofArray

    columns[0]
    |> Array.map (fun number ->
        let similarity = number |> counts.TryFind |> getSimilarity
        number * similarity)
    |> Array.sum
