module Tests

open NUnit.Framework

let input1 =
    @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet
"

let input2 =
    @" two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen"

[<Test>]
let Test1 () =
    let arr = input1.Split [| '\n' |]

    let result = Day1.resolvePart1 arr
    Assert.AreEqual(result, 142)

[<Test>]
let Test2 () =
    let arr = input2.Split [| '\n' |]

    let result = Day1.resolvePart2 arr
    Assert.AreEqual(result, 281)
