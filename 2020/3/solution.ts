import * as fs from 'fs';
import * as IO from 'fp-ts/IO';
import * as IOE from 'fp-ts/IOEither';
import * as A from 'fp-ts/Array';
import { flow, pipe } from 'fp-ts/function';

type AccumulatedSlope = {
    columnIndex: number;
    treeCount: number;
};

const filePath = 'input.txt';
const tree = '#';

const readFile = (path: string) => IOE.tryCatch(
    () => fs.readFileSync(path, 'utf-8'),
    (e) => e as Error,
);

const hasTree = (row: string, index: number) => row.charAt(index % row.length) === tree;
const add = (a: number) => (b: number) => a + b;

const handleSlopeRow = (acc: AccumulatedSlope, slopeRow: string): AccumulatedSlope => ({
    columnIndex: acc.columnIndex + 3,
    treeCount: pipe(
        pipe(hasTree(slopeRow, acc.columnIndex), Number),
        add(acc.treeCount),
    ),
});

const countTrees = A.reduce({ columnIndex: 0, treeCount: 0 }, handleSlopeRow)

const toboggan = (path: string) => pipe(
    readFile(path),
    IOE.map(flow(
        (string) => string.split('\n'),
        countTrees,
        ({ treeCount }) => treeCount.toString(),
    )),
    IOE.getOrElse((e) => IO.of(e.message)),
);


console.log(toboggan(filePath)());
