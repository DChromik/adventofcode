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

    let antennae =
        getAntennaeGroups grid.cells
        |> Seq.map (fun (_, points) -> findAllAntinodes (List.head points) (List.tail points))

    printfn "%A" antennae

    0

let resolvePart2 (lines: seq<string>) : int = 0
