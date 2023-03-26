import { QuestionOption } from './../interfaces/Option';
export interface ModifyQuestionRequest {
    id: string,
    text: string,
    options: QuestionOption[]
}