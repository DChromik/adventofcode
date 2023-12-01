import * as path from 'path';
import { createReadStream } from 'fs';
import { resolvePart1 } from './day1/solution';

async function main() {
	const file = createReadStream(path.resolve(__dirname, '../inputs/day1.txt'));
	console.log(await resolvePart1(file));
}

main();
