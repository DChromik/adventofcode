import { ReadStream } from "fs";
import { reduceLines } from "../util";

export function resolvePart1(stream: ReadStream): Promise<number> {
	return reduceLines(stream, (sum, line) => {
		const [winning, picked] = parseLine(line)
		return sum + calculatePoints(winning, picked);
	}, 0);
}

export function resolvePart2(stream: ReadStream): Promise<number> {
	const queue: number[] = [1];
	return reduceLines(stream, (sum, line) => {
		const currentCopies = queue.shift() || 1;
		const [winning, picked] = parseLine(line)
		const points = calculateCardsWon(winning, picked);
		addCopies(currentCopies, points, queue);
		return sum + currentCopies;
	}, 0);
}

function parseLine(line: string): [number[], number[]] {
	const [winning, picked] = line.split(':')[1].split('|');
	return [extractNumbers(winning), extractNumbers(picked)];
}


function extractNumbers(numbersString: string): number[] {
	const split = numbersString.split(' ').filter(Boolean);
	return split.map((n) => parseInt(n, 10));
}

function calculatePoints(winning: number[], picked: number[]): number {
	const winningSet = new Set(winning);
	const intersection = picked.filter((n) => winningSet.has(n));
	if (intersection.length === 0) {
		return 0;
	}
	return Math.pow(2, intersection.length - 1);
}

function calculateCardsWon(winning: number[], picked: number[]): number {
	const winningSet = new Set(winning);
	const intersection = picked.filter((n) => winningSet.has(n));
	return intersection.length || 0;
}

function addCopies(copies: number, points: number, queue: number[]): void {
	for (let i = 0; i < points; i += 1) {
		const currentCopies = queue[i];
		if (!currentCopies) {
			queue.push(1 + copies);
		} else {
			queue[i] = currentCopies + copies;
		}
	}
}
