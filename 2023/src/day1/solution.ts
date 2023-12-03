import { ReadStream } from 'fs';
import { reduceLines } from '../util';

export async function resolvePart1(stream: ReadStream): Promise<number> {
	return reduceLines(stream, (sum, line) => {
		return sum + handleLine(line);
	}, 0);
}

export async function resolvePart2(stream: ReadStream): Promise<number> {
	return reduceLines(stream, (sum, line) => {
		return sum + handleLine2(line);
	}, 0);
}

function handleLine(line: string): number {
	const numbers = line.split('').reduce((acc: number[], value) => {
		const number = Number.parseInt(value);
		if (!isNaN(number)) {
			if (acc.length === 0) {
				return [number, number];
			}
			return [acc[0], number];
		}
		return acc;
	}, []);
	return numbers[0] * 10 + numbers[1];
}

function handleLine2(line: string): number {
	const numbers = line.split('').reduce((acc: number[], value, index) => {
		let number = Number.parseInt(value);
		if (isNaN(number)) {
			const words = extractWords(line, index);
			number = wordToNumber(words);
}
		if (!isNaN(number)) {
			if (acc.length === 0) {
				return [number, number];
			}
			return [acc[0], number];
		}
		return acc;
	}, []);
	return numbers[0] * 10 + numbers[1];
}

const numberWords = [
	'one',
	'two',
	'three',
	'four',
	'five',
	'six',
	'seven',
	'eight',
	'nine'
];

function extractWords(line: string, startingIndex: number): string[] {
	return [
		line.substring(startingIndex, startingIndex + 3),
		line.substring(startingIndex, startingIndex + 4),
		line.substring(startingIndex, startingIndex + 5),
	]
}

function wordToNumber(words: string[]): number {
	const index = numberWords.findIndex((numberWord) => words.includes(numberWord));
	return index + 1 || NaN;
}
