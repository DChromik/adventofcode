import { ReadStream } from "fs";
import { createInterface } from "readline";

export async function resolvePart1(stream: ReadStream): Promise<number> {
	let sum = 0;
	await readLines(stream, (line) => {
		sum += handleLine(line);
	});
	return sum;
}

function readLines(stream: ReadStream, handleLine: (line: string) => void): Promise<void> {
	return new Promise((resolve) => {
		const rl = createInterface({
			input: stream,
		});
		rl.on('line', handleLine);
		rl.on('close', resolve);
	});
}

function handleLine(line: string): number {
	const numbers = line.split('').reduce((acc: number[], value) => {
		const number = Number.parseInt(value);
		if (!isNaN(number)) {
			if (acc.length === 0) {
				return [number];
			}
			return [acc[0], number];
		}
		return acc;
	}, []);
	if (numbers.length === 1) {
		return numbers[0] * 10 + numbers[0];
	}
	return numbers[0] * 10 + numbers[1];
}
