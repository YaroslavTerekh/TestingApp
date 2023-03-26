import { Answer } from './../interfaces/Answer';
export interface CheckAnswersRequest {
    id: string,
    checkAnswers: Answer[]
}