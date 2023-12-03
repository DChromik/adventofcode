import { ReadStream } from "fs";
import { createInterface } from "readline";

export async function reduceLines<T>(stream: ReadStream, handleLine: (accumulator: T, line: string, index: number) => T, initialValue: T): Promise<T> {
	return new Promise((resolve) => {
		let index = 0;
		let result = initialValue;
		const rl = createInterface({
			input: stream,
		});
		rl.on('line', (line) => {
			result = handleLine(result, line, index);
			index += 1;
		});
		rl.on('close', () => resolve(result));
	});
}

