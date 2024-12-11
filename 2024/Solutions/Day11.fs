module Day11

type Counter = (int64 * int64) seq

module Counter =
    let fromSeq seq : Counter =
        seq
        |> Seq.groupBy id
        |> Seq.map (fun (number, group) -> (number, Seq.length group |> int64))

    let group (counter: Counter) : Counter =
        counter
        |> Seq.groupBy fst
        |> Seq.map (fun (number, group) -> (number, group |> Seq.map snd |> Seq.sum))

    let collect f (counter: Counter) : Counter =
        counter
        |> Seq.collect (fun (number, count) -> f number |> Seq.map (fun n -> (n, count)))
        |> group

    let total (counter: Counter) : int64 =
        counter |> Seq.sumBy (fun (_, count) -> count)

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
    match stone with
    | 0L -> [ 1L ]
    | s when (hasEvenDigitCount s) -> splitNumber s
    | s -> [ s * 2024L ]

let stoneFolder (list: Counter) : Counter =
    list |> Counter.collect (fun stone -> applyRules stone)

let rec blinkTimes (blinksRemaining: int64) (list: Counter) =
    if blinksRemaining = 0 then
        list
    else
        blinkTimes (blinksRemaining - 1L) (stoneFolder list)

let resolvePart1 (lines: seq<string>) : int64 =
    parseInput lines |> Counter.fromSeq |> blinkTimes 25L |> Counter.total

let resolvePart2 (lines: seq<string>) : int64 =
    parseInput lines |> Counter.fromSeq |> blinkTimes 75L |> Counter.total
