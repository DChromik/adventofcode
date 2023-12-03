import { ReadStream } from "fs";
import { reduceLines } from "../util";

class Number {
	public value: number;
	public isChecked= false;

	constructor(digit: number) {
		this.value = digit;
	}
	
	public addDigit(digit: number): void {
		this.value = this.value * 10 + digit;
	}
}

class Symbol {
	constructor() {

	}
}

type Cell = null | Number | Symbol;

class Grid {
	private rows: Cell[][] = [];

	public addLine(line: string): void {
		let previousCell: Cell = null;
		const row = line.split('').map((character, index) => {
			if (character === '.') {
				previousCell = null;
				return null;
			}
			const digit = parseInt(character, 10);
			if (!isNaN(digit)) {
				if (previousCell instanceof Number) {
					previousCell.addDigit(digit);
					return previousCell;
				}
				previousCell = new Number(digit);
				return previousCell;
			}
			previousCell = null;
			return new Symbol();
		})
		this.rows.push(row);
	}

	public addAdjacentNumbers(): number {
		return this.rows.reduce((sum, row, rowIndex) => {
			return row.reduce((rowSum: number, cell, colIndex) => {
				if (cell instanceof Number) {
					if (cell.isChecked) {
						return rowSum;
					}
					if (this.hasAdjacentSymbol(rowIndex, colIndex)) {
						cell.isChecked = true;
						return rowSum + cell.value;
					}
					return rowSum;
				}
				return rowSum;
			}, sum);
		}, 0)
	}

	private hasAdjacentSymbol(row: number, column: number): boolean {
		for (let i = column - 1; i <= column + 1; i += 1) {
			const hasSymbol = this.rows[row - 1]?.[i] instanceof Symbol
				|| this.rows[row]?.[i] instanceof Symbol
				|| this.rows[row + 1]?.[i] instanceof Symbol;
			if (hasSymbol) {
				return true;
			}
		}
		return false;
	}
}

export async function resolvePart1(stream: ReadStream): Promise<number> {
	const grid = await reduceLines(stream, (grid, line) => {
		grid.addLine(line);
		return grid;
	}, new Grid());
	return grid.addAdjacentNumbers();
}

export function resolvePart2(stream: ReadStream): Promise<number> {
	return reduceLines(stream, (sum, line) => {
		return sum;
	}, 0);
}

