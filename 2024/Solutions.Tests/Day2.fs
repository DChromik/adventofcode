module Day2

open NUnit.Framework

let input =
    @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9"

[<Test>]
let Test1 () =
    let arr = input.Split [| '\n' |]

    let result = Day2.resolvePart1 arr
    Assert.AreEqual(2, result)

[<Test>]
let Test2 () =
    let arr = input.Split [| '\n' |]

    let result = Day2.resolvePart2 arr
    Assert.AreEqual(0, result)
