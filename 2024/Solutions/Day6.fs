module Day6

type Direction =
    | Up
    | Down
    | Left
    | Right

type GuardState = (int * int) * Direction

let findInitialPosition (grid: char[][]) =
    let y = grid |> Seq.findIndex (fun row -> row |> Seq.contains '^')
    let x = grid.[y] |> Seq.findIndex (fun c -> c = '^')

    (x, y)

let isInsideRoom (grid: char[][]) (x, y) =
    let height = grid.Length
    let width = grid.[0].Length

    x >= 0 && x < width && y >= 0 && y < height

let getNextPosition (x, y) direction =
    match direction with
    | Up -> (x, y - 1)
    | Down -> (x, y + 1)
    | Left -> (x - 1, y)
    | Right -> (x + 1, y)

let turnRight direction =
    match direction with
    | Up -> Right
    | Right -> Down
    | Down -> Left
    | Left -> Up

let hasObstacle (grid: char[][]) (x, y) =
    isInsideRoom grid (x, y) && grid.[y].[x] = '#'

let rec moveGuard (grid: char[][]) (position: int * int) (direction: Direction) : GuardState =
    let nextPosition = getNextPosition position direction

    if hasObstacle grid nextPosition then
        moveGuard grid position (turnRight direction)
    else
        (nextPosition, direction)

let rec moveToNextCell (grid: char[][]) (position: int * int) (direction: Direction) : seq<GuardState> =
    seq {
        let (nextPosition, nextDirection) = moveGuard grid position direction

        if isInsideRoom grid nextPosition then
            yield (nextPosition, nextDirection)
            yield! moveToNextCell grid nextPosition nextDirection
    }

let getVisitedCells (grid: char[][]) : seq<GuardState> =
    seq {
        let initialPosition = findInitialPosition grid

        yield (initialPosition, Up)

        yield! moveToNextCell grid initialPosition Up
    }

let parseLinesToGrid (lines: seq<string>) : char[][] =
    lines |> Seq.map (fun line -> line.Trim().ToCharArray()) |> Seq.toArray

let resolvePart1 (lines: seq<string>) : int =
    parseLinesToGrid lines
    |> getVisitedCells
    |> Seq.map fst
    |> Set.ofSeq
    |> Set.count

let changeElementImmutable (arr: char[][]) (x: int) (y: int) (newValue: char) =
    arr
    |> Array.mapi (fun rowIdx row ->
        if rowIdx = y then
            row |> Array.mapi (fun colIdx elem -> if colIdx = x then newValue else elem)
        else
            row)

let isPathLooped (grid: char[][]) =
    let initialPosition = findInitialPosition grid
    let mutable visitedPaths = set [ (initialPosition, Up) ]

    moveToNextCell grid initialPosition Up
    |> Seq.exists (fun state ->
        if Set.contains state visitedPaths then
            true
        else
            visitedPaths <- visitedPaths.Add state
            false)

let resolvePart2 (lines: seq<string>) : int =
    let grid = parseLinesToGrid lines

    let loopedPaths =
        grid
        |> getVisitedCells
        |> Seq.map fst
        |> Set.ofSeq
        |> Seq.map (fun (x, y) ->
            if grid.[y].[x] = '.' then
                isPathLooped (changeElementImmutable grid x y '#')
            else
                false)
        |> Seq.map (fun looped -> if looped then 1 else 0)
        |> Seq.sum

    loopedPaths
