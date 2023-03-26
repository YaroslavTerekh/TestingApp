import { QuestionOption } from './../interfaces/Option';
export interface CreateQuestionRequest {
    testId: string,
    text: string,
    options: QuestionOption[]
}