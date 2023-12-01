import { ReadStream } from "fs";
import { createInterface } from "readline/promises";

export function resolvePart1(stream: ReadStream): number {
	const rl = createInterface({
		input: stream,
	});
	rl.on('line', console.log);
	rl.on('close', () => console.log('END OF FILE'));
	return 0;
}
