import { ReadStream } from "fs";
import { reduceLines } from "../util";

export async function resolvePart1(stream: ReadStream): Promise<number> {
	const mapper = await reduceLines(stream, (mapper, line, index) => {
		if (index === 0) {
			return { ...mapper, seeds: mapSeeds(line) };
		} else {
			mapper.mapper.addMapping(line);
		}
		return mapper;
	}, { seeds: [] as number[], mapper: new SeedMapper() });
	const locations = mapper.mapper.mapSeeds(mapper.seeds);
	return locations.reduce((lowest, current) => {
		return current < lowest ? current : lowest;
	}, Infinity);
}

export async function resolvePart2(stream: ReadStream): Promise<number> {
	const { ranges, mapper } = await reduceLines(stream, (config, line, index) => {
		if (index === 0) {
			config.ranges = mapSeedRanges(line);
		} else {
			config.mapper.addMapping(line);
		}
		return config;
	}, { ranges: [] as Range[], mapper: new SeedMapper() });
	const locationRanges = mapper.mapRanges(ranges);
	console.log(locationRanges);
	return 0;
}

function mapSeeds(line: string): number[] {
	return line.split(': ')[1].split(' ').map((n) => parseInt(n, 10));
}

function mapSeedRanges(line: string): Range[] {
	const numbers = line.split(': ')[1].split(' ').map((n) => parseInt(n, 10));
	const ranges = [];
	for (let i = 0; i < numbers.length; i += 2) {
		ranges.push(new Range(numbers[i], numbers[i + 1]));
	}
	return ranges;
}

class SeedMapper {
	private mappings: Mapping[][] = [];
	private currentMapping: Mapping[] = [];

	public addMapping(line: string): void {
		if (line.length === 0) return;

		if (line.includes('map:')) {
			this.currentMapping = [];
			this.mappings.push(this.currentMapping);
		} else {
			this.currentMapping.push(new Mapping(line))
		}
	}

	public mapSeeds(seeds: number[]): number[] {
		return seeds.map((seed) => {
			return this.mappings.reduce((value, mapping) => {
				return mapValue(mapping, value);
			}, seed);
		});
	}

	public mapRanges(seedRanges: Range[]): Range[] {
		return this.mappings.reduce((ranges, mapping) => {
			console.log(ranges);
			const result = mapping.flatMap((m) => mapRange(m, ranges))
			console.log(result);
			return result;
		}, seedRanges);
	}
}

class Mapping {
	private from: number;
	private to: number;
	private amountChanged: number;

	constructor(line: string) {
		const [destination, source, length] = line.split(' ').map((n) => parseInt(n, 10));
		this.amountChanged = destination - source;
		this.from = source;
		this.to = source + length - 1;
	}

	public canMap(value: number): boolean {
		return value <= this.to && value >= this.from;
	}

	public canMapRange(range: Range): boolean {
		return range.from <= this.to && range.to >= this.from;
	}

	public mapValue(source: number): number {
		return source + this.amountChanged;
	}

	public mapRange(range: Range): Range[] {
		const mappedRanges = [];
		if (range.from < this.from) {
			mappedRanges.push(new Range(range.from, this.from - range.from));
		}

		const from = range.from < this.from - 1 ? this.from : range.from;
		const to = this.to + 1 < range.to ? this.to : range.to;
		mappedRanges.push(new Range(from + this.amountChanged, to - from + 1));
		if (range.to > this.to) {
			mappedRanges.push(new Range(this.to + 1, range.to - this.to));
		}
		return mappedRanges;
	}
}

class Range {
	public readonly from: number;
	public readonly to: number;

	constructor(from: number, count: number) {
		this.from = from;
		this.to = from + count - 1;
	}
}

function mapValue(mappings: Mapping[], value: number): number {
	const mapping = mappings.find((m) => m.canMap(value));
	return mapping ? mapping.mapValue(value) : value;
}

function mapRange(mapping: Mapping, ranges: Range[]): Range[] {
	return ranges.reduce((mappedRanges, range) => {
		if (mapping.canMapRange(range)) {
			return [...mappedRanges, ...mapping.mapRange(range)];
		}
		return [...mappedRanges, range];
	}, [] as Range[]);
}
