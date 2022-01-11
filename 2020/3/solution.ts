import * as fs from 'fs';
import * as IO from 'fp-ts/IO';
import * as IOE from 'fp-ts/IOEither';
import * as A from 'fp-ts/Array';
import { flow, pipe } from 'fp-ts/function';

type TraversalConfig = {
    down: number;
    right: number;
};

type AccumulatedSlope = {
    row: number;
    column: number;
    treeCount: number;
};

const filePath = 'input.txt';
const tree = '#';
const startAcc: AccumulatedSlope = {
    column: 0,
    row: 0,
    treeCount: 0,
};

const readFile = (path: string) => IOE.tryCatch(
    () => fs.readFileSync(path, 'utf-8'),
    (e) => e as Error,
);

const hasTree = (row: string, index: number) => row.charAt(index % row.length) === tree;
const add = (a: number) => (b: number) => a + b;

const incrementAcc = (config: TraversalConfig) => (acc: AccumulatedSlope): AccumulatedSlope => ({
    row: acc.row + config.down,
    column: acc.column + config.right,
    treeCount: 0,
})

const traverseSlope = (config: TraversalConfig) => (slope: string[]) => (acc: AccumulatedSlope = startAcc): number => (
    slope.length < add(acc.row)(config.down) ? 0
        : add(
            Number(hasTree(slope[acc.row], acc.column))
        )(
            traverseSlope(config)(slope)(incrementAcc(config)(acc))
        )
);

const startTraversal = (config: TraversalConfig) => (slope: string[]):number => traverseSlope(config)(slope)();

const toboggan = pipe(
    readFile(filePath),
    IOE.map(flow(
        (string) => string.split('\n'),
        startTraversal({ down: 1, right: 3 }),
        String,
    )),
    IOE.getOrElse((e) => IO.of(e.message)),
);

const slopes: TraversalConfig[] = [
    { right: 1, down: 1 },
    { right: 3, down: 1 },
    { right: 5, down: 1 },
    { right: 7, down: 1 },
    { right: 1, down: 2 },
]

const bonusToboggan = pipe(
    readFile(filePath),
    IOE.map(flow(
        (string) => string.split('\n'),
        (grid) => pipe(
            slopes,
            A.map((slope) => startTraversal(slope)(grid)),
            A.reduce(1, (acc, treeCount) => acc * treeCount),
            String,
        ),
    )),
    IOE.getOrElse((e) => IO.of(e.message))
)

console.log(toboggan());
console.log(bonusToboggan());
