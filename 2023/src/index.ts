import * as path from 'path';
import { createReadStream } from 'fs';
import { resolvePart1, resolvePart2
 } from './day1/solution';

async function main() {
	let file = createReadStream(path.resolve(__dirname, '../inputs/day1.txt'));
	const part1 = await resolvePart1(file);
	console.log('Part 1: ', part1);

	file = createReadStream(path.resolve(__dirname, '../inputs/day1.txt'));
	const part2 = await resolvePart2(file);
	console.log('Part 2: ', part2);
}

main();
