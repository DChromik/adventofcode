module Day4

let direction =
    [| (1, 0); (-1, 0); (0, 1); (0, -1); (1, 1); (1, -1); (-1, 1); (-1, -1) |]

let targetWord = "XMAS"

let linesToArray (lines: seq<string>) : char[][] =
    lines
    |> Seq.map (fun line -> line.Replace("\r", "") |> Seq.toArray)
    |> Seq.toArray

let getWord (grid: char[][]) (length: int) (x: int, y: int) (dx: int, dy: int) : seq<char> =
    seq {
        let endX = x + (dx * (length - 1))
        let endY = y + (dy * (length - 1))

        let isWithinBounds =
            endX < grid.[y].Length && endX >= 0 && endY < grid.Length && endY >= 0

        if isWithinBounds then
            for i = 0 to length - 1 do
                yield grid.[y + dy * i].[x + dx * i]
    }

let hasDiagonalMas (grid: char[][]) (x: int, y: int) : int =
    let isWithinBounds =
        x >= 1 && y >= 1 && x + 1 < grid.[y].Length && y + 1 < grid.Length

    if isWithinBounds then
        let word1 = getWord grid 3 (x - 1, y - 1) (1, 1) |> Seq.toArray |> System.String
        let word2 = getWord grid 3 (x + 1, y + 1) (-1, -1) |> Seq.toArray |> System.String

        if (word1 = "MAS" || word1 = "SAM") && (word2 = "MAS" || word2 = "SAM") then
            1
        else
            0
    else
        0

let countXmasWords (grid: char[][]) (x: int) (y: int) : int =
    direction
    |> Array.map (fun direction -> getWord grid 4 (x, y) direction |> Seq.toArray |> System.String)
    |> Array.map (fun word -> if word = targetWord then 1 else 0)
    |> Array.sum

let resolvePart1 (lines: seq<string>) : int =
    let grid = linesToArray lines

    grid
    |> Array.mapi (fun y row -> row |> Array.mapi (fun x _ -> countXmasWords grid x y) |> Array.sum)
    |> Array.sum

let resolvePart2 (lines: seq<string>) : int =
    let grid = linesToArray lines

    grid
    |> Array.mapi (fun y row -> row |> Array.mapi (fun x _ -> hasDiagonalMas grid (x, y)) |> Array.sum)
    |> Array.sum
