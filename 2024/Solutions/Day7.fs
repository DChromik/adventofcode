module Day7

let parseLine (lines: seq<string>) : seq<int64 * seq<int64>> =
    lines
    |> Seq.map (fun line ->
        let splitLine = line.Split(":")
        let target = splitLine |> Seq.head |> int64

        let numbers =
            splitLine
            |> Seq.last
            |> (fun numbers -> numbers.Trim().Split(" ") |> Array.map int64)

        (target, numbers))

let rec getPermutations (numbers: seq<int64>) (acc: int64) : seq<int64> =
    seq {
        match (Seq.tryHead numbers) with
        | Some(x) ->
            yield! getPermutations (Seq.tail numbers) (acc + x)
            yield! getPermutations (Seq.tail numbers) (acc * x)
        | None -> yield acc
    }

let resolvePart1 (lines: seq<string>) : int64 =
    let parsedLines = parseLine lines

    parsedLines
    |> Seq.map (fun (targetValue, numbers) ->
        let hasCombination =
            getPermutations (Seq.tail numbers) (Seq.head numbers)
            |> Seq.exists (fun res -> res = targetValue)

        if hasCombination then targetValue else 0)
    |> Seq.sum

let resolvePart2 (lines: seq<string>) : int = 0
