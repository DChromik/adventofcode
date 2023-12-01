import * as path from 'path';
import { createReadStream } from 'fs';
import { resolvePart1 } from "./solution";

describe('day1', () => {
	it('should resolve part1', async () => {
		const file = createReadStream(path.resolve(__dirname, './input_small.txt'));
		const output = await resolvePart1(file);
		expect(output).toEqual(142);
	});
});
