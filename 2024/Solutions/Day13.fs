module Day13

open System.Text.RegularExpressions

type Robot =
    { position: int * int
      velocity: int * int }

let pattern = Regex(@"p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)")

let parseInput (lines: seq<string>) =
    lines
    |> Seq.map pattern.Match
    |> Seq.map (fun m ->
        { position = (int m.Groups[1].Value, int m.Groups[2].Value)
          velocity = (int m.Groups[3].Value, int m.Groups[4].Value) })

let moveRobot (width: int, height: int) (robot: Robot) =
    let (x, y) = robot.position
    let (dx, dy) = robot.velocity

    let resX =
        match (x + dx * 100) % width with
        | res when res >= 0 -> res
        | res -> res + width

    let resY =
        match (y + dy * 100) % height with
        | res when res >= 0 -> res
        | res -> res + height

    (resX, resY)

let getQuadrantIndex (width: int, height: int) (position: int * int) =
    let midX = width / 2
    let midY = height / 2

    match position with
    | (x, y) when x < midX && y < midY -> Some 0
    | (x, y) when x > midX && y < midY -> Some 1
    | (x, y) when x < midX && y > midY -> Some 2
    | (x, y) when x > midX && y > midY -> Some 3
    | _ -> None

let countQuadrants (bounds: int * int) (positions: seq<int * int>) =
    positions
    |> Seq.choose (getQuadrantIndex bounds)
    |> Seq.groupBy id
    |> Seq.map snd
    |> Seq.map Seq.length
    |> Seq.reduce (fun a b -> a * b)

let resolvePart1 (lines: seq<string>) : int =
    parseInput lines |> Seq.map (moveRobot (101, 103)) |> countQuadrants (101, 103)

let testPart1 (lines: seq<string>) : int =
    parseInput lines |> Seq.map (moveRobot (11, 7)) |> countQuadrants (11, 7)

let resolvePart2 (lines: seq<string>) : int = 0
