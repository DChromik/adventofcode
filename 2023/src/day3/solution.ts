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
	public readonly isGear: boolean;

	constructor(isGear: boolean) {
		this.isGear = isGear;
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
			return new Symbol(character === '*');
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

	public addGearValues(): number {
		return this.rows.reduce((sum, row, rowIndex) => {
			return row.reduce((rowSum: number, cell, colIndex) => {
				if (cell instanceof Symbol && cell.isGear) {
					const neighbours = this.getUniqueNeighbours(rowIndex, colIndex);
					if (neighbours.length === 2) {
						return rowSum + neighbours[0].value * neighbours[1].value;
					}
				}
				return rowSum;
			}, sum);
		}, 0)

	}

	private getUniqueNeighbours(row: number, column: number): Number[] {
		const neighbours = new Set<Number>();
		for (let x = column - 1; x <= column + 1; x += 1) {
			for (let y = row - 1; y <= row + 1; y += 1) {
				const cell = this.rows[y][x];
				if (cell instanceof Number && !neighbours.has(cell)) {
					neighbours.add(cell)
				}
			}
		}
		return Array.from(neighbours);
	}
}

export async function resolvePart1(stream: ReadStream): Promise<number> {
	const grid = await reduceLines(stream, (grid, line) => {
		grid.addLine(line);
		return grid;
	}, new Grid());
	return grid.addAdjacentNumbers();
}

export async function resolvePart2(stream: ReadStream): Promise<number> {
	const grid = await reduceLines(stream, (grid, line) => {
		grid.addLine(line);
		return grid;
	}, new Grid());
	return grid.addGearValues();
}

