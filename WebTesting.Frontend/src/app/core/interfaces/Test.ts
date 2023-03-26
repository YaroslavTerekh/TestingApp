import { User } from './User';
import { Question } from "./Question";

export interface Test {
    id: string,
    title: string,
    description: string,
    questions: Question[],
    users: User[]
}