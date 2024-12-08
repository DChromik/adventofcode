module Day8

type Grid =
    { cells: char[][]
      width: int
      height: int }

let parseToGrid (lines: seq<string>) : Grid =
    let cells = lines |> Seq.map (fun line -> line.Trim().ToCharArray()) |> Array.ofSeq

    { cells = cells
      height = cells.Length
      width = cells[0].Length }

let getAntennaeGroups (cells: char[][]) =
    cells
    |> Seq.mapi (fun y row -> row |> Seq.mapi (fun x cell -> (cell, (x, y))))
    |> Seq.reduce Seq.append
    |> Seq.groupBy fst
    |> Seq.filter (fun (c, _) -> not (c = '.'))
    |> Seq.map (fun (t, points) -> (t, points |> Seq.map snd |> List.ofSeq))

let distance (a: int * int) (b: int * int) = (fst a - fst b, snd a - snd b)

let addPoints (a: int * int) (b: int * int) = (fst a + fst b, snd a + snd b)

let isWithinBounds (width, height) (x, y) =
    x >= 0 && x < width && y >= 0 && y < height

let getAntinodes (a: int * int) (b: int * int) =
    seq {
        yield distance a b |> addPoints a
        yield distance b a |> addPoints b
    }

let rec findAllAntinodes (a: int * int) (arr: list<int * int>) =
    seq {
        match arr with
        | [] -> ()
        | b :: tail ->
            yield! getAntinodes a b
            yield! findAllAntinodes a tail
            yield! findAllAntinodes b tail
    }

let resolvePart1 (lines: seq<string>) : int =
    let grid = parseToGrid lines

    getAntennaeGroups grid.cells
    |> Seq.map (fun (_, points) -> findAllAntinodes (List.head points) (List.tail points))
    |> Seq.reduce Seq.append
    |> Seq.filter (fun p -> isWithinBounds (grid.width, grid.height) p)
    |> Seq.distinct
    |> Seq.length

let rec getPointsWithinBounds (bounds: int * int) (direction: int * int) (point: int * int) =
    seq {
        if isWithinBounds bounds point then
            yield point
            yield! getPointsWithinBounds bounds direction (addPoints point direction)
    }

let getAntinodesWithinBounds (bounds: int * int) (a: int * int) (b: int * int) =
    seq {
        yield a
        yield b
        yield! getPointsWithinBounds bounds (distance a b) a
        yield! getPointsWithinBounds bounds (distance b a) b
    }

let rec findAllAntinodesWithResonance (bounds: int * int) (a: int * int) (arr: list<int * int>) =
    seq {
        match arr with
        | [] -> ()
        | b :: tail ->
            yield! getAntinodesWithinBounds bounds a b
            yield! findAllAntinodesWithResonance bounds a tail
            yield! findAllAntinodesWithResonance bounds b tail
    }

let resolvePart2 (lines: seq<string>) : int =
    let grid = parseToGrid lines

    getAntennaeGroups grid.cells
    |> Seq.map (fun (_, points) ->
        findAllAntinodesWithResonance (grid.width, grid.height) (List.head points) (List.tail points))
    |> Seq.reduce Seq.append
    |> Seq.filter (fun p -> isWithinBounds (grid.width, grid.height) p)
    |> Seq.distinct
    |> Seq.length
