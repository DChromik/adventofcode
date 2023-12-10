import { ReadStream } from "fs";
import { reduceLines } from "../util";

export async function resolvePart1(stream: ReadStream): Promise<number> {
	const result = await reduceLines(stream, (acc) => {
		return acc;
	}, 0);
	return result;
}

export async function resolvePart2(stream: ReadStream): Promise<number> {
	const result = await reduceLines(stream, (acc) => {
		return acc;
	}, 0);
	return result;
}

