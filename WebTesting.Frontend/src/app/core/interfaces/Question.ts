import { QuestionOption } from "./Option"

export interface Question {
    id: string,
    testId: string,
    options: QuestionOption[],
    questionDescription: string
}