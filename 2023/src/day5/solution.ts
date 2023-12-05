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

export function resolvePart2(stream: ReadStream): Promise<number> {
	return reduceLines(stream, (sum, line) => {
		return sum;
	}, 0);
}

function mapSeeds(line: string): number[] {
	return line.split(': ')[1].split(' ').map((n) => parseInt(n, 10));
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

	public mapValue(source: number): number {
		return source + this.amountChanged;
	}
}

function mapValue(mappings: Mapping[], value: number): number {
	const mapping = mappings.find((m) => m.canMap(value));
	return mapping ? mapping.mapValue(value) : value;
}
