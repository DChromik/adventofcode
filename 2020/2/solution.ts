import * as fs from 'fs';
import {
    either, string,
    array as A,
    nonEmptyArray as NEA,
} from 'fp-ts';
import { pipe, flow } from 'fp-ts/function';

const safeSplit = (ch: string) => flow(
    string.split(ch),
    NEA.fromReadonlyNonEmptyArray,
);

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
const input: NEA.NonEmptyArray<string> = pipe(file, safeSplit('\n'));

type CountFunc = ([min, max, char]: string[]) => (s: string) => boolean;
const verifyPassword: (fn: CountFunc) => (r: string) => (p: string) => boolean
= (countType) => (rules) => (pass): boolean => pipe(
    rules,
    safeSplit('-'),
    A.chain(safeSplit(' ')),
    countType,
)(pass);
const result: (fn: CountFunc) => number
= (countType) => pipe(
    input,
    A.map<string, [string, string]>(
        flow(
            string.split(': '),
            (v) => [v[0], v[1]],
        )
    ),
    A.map(([r, p]) => verifyPassword(countType)(r)(p)),
    A.filter(Boolean),
).length;

const baseCountFunc: CountFunc = ([min, max, char]) => flow(
    safeSplit(''),
    A.map((v) => v === char),
    A.filter(Boolean),
    A.reduce(0, (t, c) => t + (c ? 1 : 0)),
    (c) => (c >= Number(min) && c <= Number(max))
);
const bonusCountFunc: CountFunc = ([min, max, char]) => flow(
    safeSplit(''),
    (p) => (((
            p[Number(min) - 1] === char
        ) || (
            p[Number(max) - 1] === char
    )) && (
        p[Number(min) - 1] != p[Number(max) - 1]
    )
)
);

console.log('base:', result(baseCountFunc));
console.log('bonus:', result(bonusCountFunc));