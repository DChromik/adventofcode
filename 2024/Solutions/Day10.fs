module Day10

let parseLineToGrid (lines: seq<string>) =
    lines
    |> Seq.map (fun l -> l.Trim().ToCharArray() |> Array.map (fun c -> c.ToString() |> int))
    |> Seq.toArray

let getItem (grid: int[][]) (x, y) =
    grid
    |> Array.tryItem y
    |> Option.map (fun row -> row |> Array.tryItem x)
    |> Option.flatten
    |> Option.map (fun height -> (height, (x, y)))

let getNeighbours (grid: int[][]) (x, y) =
    seq {
        getItem grid (x + 1, y)
        getItem grid (x - 1, y)
        getItem grid (x, y + 1)
        getItem grid (x, y - 1)
    }

let rec getTrailScore (grid: int[][]) (position: int * int) (height: int) : seq<int * int> =
    seq {
        if height = 9 then
            yield position
        else
            let neighbours =
                getNeighbours grid position
                |> Seq.choose (fun neighbour ->
                    match neighbour with
                    | Some(nextHeight, nextPosition) when nextHeight = (height + 1) -> Some((nextHeight, nextPosition))
                    | _ -> None)

            for (nextHeight, nextPosition) in neighbours do
                yield! getTrailScore grid nextPosition nextHeight
    }

let resolvePart1 (lines: seq<string>) : int =
    let grid = parseLineToGrid lines

    grid
    |> Seq.indexed
    |> Seq.fold
        (fun totalScore (y, row) ->
            row
            |> Seq.indexed
            |> Seq.fold
                (fun rowScore (x, trailhead) ->
                    match trailhead with
                    | 0 ->
                        let score = getTrailScore grid (x, y) 0 |> Set.ofSeq |> Seq.length

                        rowScore + score
                    | _ -> rowScore)
                totalScore)
        0

let resolvePart2 (lines: seq<string>) : int =
    let grid = parseLineToGrid lines

    grid
    |> Seq.indexed
    |> Seq.fold
        (fun totalScore (y, row) ->
            row
            |> Seq.indexed
            |> Seq.fold
                (fun rowScore (x, trailhead) ->
                    match trailhead with
                    | 0 ->
                        let score = getTrailScore grid (x, y) 0 |> Seq.length

                        rowScore + score
                    | _ -> rowScore)
                totalScore)
        0
