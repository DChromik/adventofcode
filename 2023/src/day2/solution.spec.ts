import * as path from 'path';
import { createReadStream } from 'fs';
import { resolvePart1, resolvePart2 } from "./solution";

describe('day2', () => {
	it('should resolve part1', async () => {
		const file = createReadStream(path.resolve(__dirname, './inputSmall1.txt'));
		const output = await resolvePart1(file);
		expect(output).toEqual(8);
	});

	it.skip('should resolve part2', async () => {
		const file = createReadStream(path.resolve(__dirname, './inputSmall2.txt'));
		const output = await resolvePart2(file);
		expect(output).toEqual(281);
	});
});
