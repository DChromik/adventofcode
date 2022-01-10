import * as fs from 'fs';
import {
    option, either, number, string,
    array as A,
    nonEmptyArray as NEA,
} from 'fp-ts';
import { pipe, flow } from 'fp-ts/function';

const filePath = 'input.txt';
const file: string = pipe(
    either.tryCatch(
        flow(
            () => fs.readFileSync(filePath, 'utf-8'),
            string.trim,
        ),
        either.toError,
    ),
    either.getOrElse(() => 'failed to get file'),
);
const input: NEA.NonEmptyArray<number> = pipe(file,
    string.split('\n'),
    NEA.fromReadonlyNonEmptyArray,
    NEA.map(Number),
);

const equal2020 = (a: number) => (b: number): option.Option<number[]> => (a + b === 2020)
    ? option.of([a, b])
    : option.none;

const result = pipe(
    pipe(NEA.of(equal2020), NEA.ap(input), NEA.ap(input)),
    A.filter(option.isSome),
    A.map(flow(
        ({ value }) => value,
        ([a, b]) => a * b,
    )),
    A.uniq(number.Eq)
)
console.log(result);

const equal2020bonus = (a: number) => (b: number) => (c: number)
: option.Option<number[]> => (a + b + c === 2020)
    ? option.of([a, b, c])
    : option.none;

const resultB = pipe(
    input,
    NEA.map(equal2020bonus),
    NEA.ap(input),
    NEA.ap(input),
    A.filter(option.isSome),
    A.map(({ value }) => value),
    A.map(([a, b, c]) => a * b * c),
    A.uniq(number.Eq)
)
console.log(resultB);