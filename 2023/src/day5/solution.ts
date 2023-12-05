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
	const mapper = await reduceLines(stream, (mapper, line, index) => {
		if (index === 0) {
			return { ...mapper, seeds: mapSeedRanges(line) };
		} else {
			mapper.mapper.addMapping(line);
		}
		return mapper;
	}, { seeds: [] as Range[], mapper: new SeedMapper() });
	for (let location = 0; location < Infinity; location += 1) {
		const seed = mapper.mapper.getSeed(location);
		const isSeed = mapper.seeds.some((seedRange) => {
			return seedRange.from <= seed && seed <= seedRange.to;
		});
		if (isSeed) {
			return location;
		}

	}
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

	public getSeed(location: number): number {
		return this.mappings.reduceRight((value, mapping) => {
			return reverseMapValue(mapping, value);
		}, location)
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

	public canReverseMap(value: number): boolean {
		return this.canMap(this.reverseMapValue(value));
	}
	public mapValue(source: number): number {
		return source + this.amountChanged;
	}

	public reverseMapValue(source: number): number {
		return source - this.amountChanged;
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

function reverseMapValue(mappings: Mapping[], value: number): number {
	const mapping = mappings.find((m) => m.canReverseMap(value));
	return mapping ? mapping.reverseMapValue(value) : value;
}

