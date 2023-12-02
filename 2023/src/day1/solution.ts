import { ReadStream } from "fs";
import { createInterface } from "readline";

export async function resolvePart1(stream: ReadStream): Promise<number> {
	return reduceLines(stream, (sum, line) => {
		return sum + handleLine(line);
	}, 0);
}

export async function resolvePart2(stream: ReadStream): Promise<number> {
	return 0;
}

async function reduceLines<T>(stream: ReadStream, handleLine: (accumulator: T, line: string) => T, initialValue: T): Promise<T> {
	return new Promise((resolve) => {
		let result = initialValue;
		const rl = createInterface({
			input: stream,
		});
		rl.on('line', (line) => { result = handleLine(result, line); });
		rl.on('close', () => resolve(result));
	});
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
