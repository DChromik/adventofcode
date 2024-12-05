module Day5

let arrayToTuple (arr: string[]) = (int arr.[0], int arr.[1])

let hasOverlap (a: seq<int>) (b: seq<int>) : bool =
    a |> Seq.exists (fun n -> Seq.contains n b)

let parseKeyValueLines (lines: seq<string>) =
    lines
    |> Seq.filter (fun l -> l.Contains('|'))
    |> Seq.map (fun l -> l.Split('|') |> arrayToTuple)
    |> Seq.groupBy snd
    |> Seq.map (fun (key, group) -> key, group |> Seq.map fst |> Array.ofSeq)
    |> Map.ofSeq

let isLineValid (map: Map<int, int[]>) (numbers: seq<int>) =
    numbers
    |> Seq.indexed
    |> Seq.forall (fun (index, num) ->
        let followingNumbers = numbers |> Seq.skip index

        match map |> Map.tryFind num with
        | Some forbiddenNumbers -> not (hasOverlap followingNumbers forbiddenNumbers)
        | None -> true)

let findMiddleElement (numbers: seq<int>) =
    let midIndex = Seq.length numbers / 2

    numbers
    |> Seq.indexed
    |> Seq.pick (fun (i, num) -> if i = midIndex then Some num else None)

let resolvePart1 (lines: seq<string>) : int =
    let map = parseKeyValueLines lines

    let processedLines =
        lines
        |> Seq.filter (fun l -> l.Contains(','))
        |> Seq.map (fun l -> l.Split(",") |> Seq.map int)
        |> Seq.map (fun numbers ->
            if isLineValid map numbers then
                findMiddleElement numbers
            else
                0)

    processedLines |> Seq.sum

let sortNumbers (map: Map<int, int[]>) (numbers: seq<int>) =
    numbers
    |> Seq.sortWith (fun a b ->
        match Map.tryFind a map with
        | Some numbersBefore -> if Seq.contains b numbersBefore then -1 else 1
        | None -> 0)

let resolvePart2 (lines: seq<string>) : int =
    let map = parseKeyValueLines lines

    let processedLines =
        lines
        |> Seq.filter (fun l -> l.Contains(','))
        |> Seq.map (fun l -> l.Split(",") |> Seq.map int)
        |> Seq.map (fun numbers ->
            if not (isLineValid map numbers) then
                numbers |> sortNumbers map |> findMiddleElement
            else
                0)

    processedLines |> Seq.sum
