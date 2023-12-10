import { ReadStream } from "fs";
import { reduceLines } from "../util";

export async function resolvePart1(stream: ReadStream): Promise<number> {
	const [times, distances] = await reduceLines(stream, (sum, line) => {
		return [...sum, extractNumbers(line)];
	}, [] as number[][]);
	const possibleWins = times.map((time, index) => {
		const distance = distances[index];
		return getPossibleWins(time, distance);
	});
	return possibleWins.reduce(multiply, 1);
}

export async function resolvePart2(stream: ReadStream): Promise<number> {
	const [time, distance] = await reduceLines(stream, (sum, line) => {
		return [...sum, extractNumber(line)];
	}, [] as number[]);
	return getPossibleWins(time, distance);
}

function extractNumbers(line: string): number[] {
	const numbers = line.split(':')[1].trim();
	return numbers.split(' ').filter(Boolean).map((n) => parseInt(n, 10));
}

function extractNumber(line: string): number {
	const number = line.split(':')[1].replaceAll(' ', '');
	return parseInt(number, 10);
}

function getPossibleWins(time: number, distance: number): number {
	let wins = 0;
	for (let i = 0; i < time; i += 1) {
		const distanceTravelled = i * (time - i);
		if (distanceTravelled > distance) {
			wins += 1;
		}
	}
	return wins;
}

function multiply(a: number, b: number) {
	return a * b;
}
