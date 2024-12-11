module Day11

let parseInput (lines: seq<string>) =
    lines |> Seq.head |> (fun l -> l.Split(" ") |> Array.map int64 |> List.ofArray)

let getDigitCount (n: int64) = n.ToString().Length |> int64

let isEven (n: int64) = n % 2L = 0L

let hasEvenDigitCount = getDigitCount >> isEven

let splitNumber (n: int64) =
    n.ToString()
    |> (fun s -> s.ToCharArray() |> Array.splitAt (s.Length / 2))
    |> (fun (a, b) -> [ System.String a |> int64; System.String b |> int64 ])

let applyRules (stone: int64) =
    seq {
        match stone with
        | 0L -> 1L
        | s when (hasEvenDigitCount s) -> yield! splitNumber s
        | s -> s * 2024L
    }

let stoneFolder (list: seq<int64>) pass : seq<int64> =
    printfn $"Pass number {pass}"


    seq {
        for stone in list do
            yield! applyRules stone
    }

let rec blinkTimes (blinksRemaining: int64) (list: seq<int64>) =
    if blinksRemaining = 0 then
        list
    else
        blinkTimes (blinksRemaining - 1L) (stoneFolder list (75L - blinksRemaining))

let resolvePart1 (lines: seq<string>) : int64 =
    parseInput lines |> blinkTimes 25L |> Seq.length |> int64

let resolvePart2 (lines: seq<string>) : int64 =
    parseInput lines |> blinkTimes 75L |> Seq.length |> int64
