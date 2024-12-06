module Day6

type Direction =
    | Up
    | Down
    | Left
    | Right

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

let rec moveGuard (grid: char[][]) (position: int * int) (direction: Direction) : (int * int) * Direction =
    let nextPosition = getNextPosition position direction

    if hasObstacle grid nextPosition then
        moveGuard grid position (turnRight direction)
    else
        (nextPosition, direction)

let rec moveToNextCell (grid: char[][]) (position: int * int) (direction: Direction) : seq<int * int> =
    seq {
        let (nextPosition, nextDirection) = moveGuard grid position direction


        if isInsideRoom grid nextPosition then
            yield nextPosition
            yield! moveToNextCell grid nextPosition nextDirection
    }

let getVisitedCells (grid: char[][]) : seq<int * int> =
    seq {
        let initialPosition = findInitialPosition grid

        yield initialPosition

        yield! moveToNextCell grid initialPosition Up
    }

let parseLinesToGrid (lines: seq<string>) : char[][] =
    lines |> Seq.map (fun line -> line.Trim().ToCharArray()) |> Seq.toArray

let resolvePart1 (lines: seq<string>) : int =
    let grid = parseLinesToGrid lines

    getVisitedCells grid |> Set.ofSeq |> Set.count

let resolvePart2 (lines: seq<string>) : int = 0
