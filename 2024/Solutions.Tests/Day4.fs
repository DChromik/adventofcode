module Day4

open NUnit.Framework

let input =
    @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX"

let input2 =
    @".M.S......
..A..MSMS.
.M.S.MAA..
..A.ASMSM.
.M.S.M....
..........
S.S.S.S.S.
.A.A.A.A..
M.M.M.M.M.
.........."

[<Test>]
let Test1 () =
    let arr = input.Split('\n')

    let result = Day4.resolvePart1 arr
    Assert.AreEqual(18, result)

[<Test>]
let Test2 () =
    let arr = input2.Split('\n')

    let result = Day4.resolvePart2 arr
    Assert.AreEqual(9, result)
