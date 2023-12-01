import { createReadStream } from 'fs';
import { resolvePart1 } from "./solution";

describe('day1', () => {
	it('should resolve part1', () => {
		const file = createReadStream('./input_small.txt');
		const output = resolvePart1(file);
		expect(output).toEqual(142);
	});
});
