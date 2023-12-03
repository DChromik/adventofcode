import yargs from 'yargs';
import { hideBin } from 'yargs/helpers';
import * as path from 'path';
import { createReadStream } from 'fs';
import { resolve } from './days';

const args = yargs(hideBin(process.argv)).options({
	d: { alias: 'day', describe: 'AoC 2023 day', type: 'number', demandOption: true },
	p: { alias: 'part', describe: 'AoC part 1 or 2 of the days problem', type: 'number', demandOption: true, choices: [1, 2] }
}).parseSync();

(async function main() {
	const { d: day, p: part } = args;
	const file = createReadStream(path.resolve(__dirname, `../inputs/day${day}.txt`));
	const result = await resolve[day - 1][part - 1](file);
	console.log('Results for day %d, part %d: %s', day, part, result);
})();

