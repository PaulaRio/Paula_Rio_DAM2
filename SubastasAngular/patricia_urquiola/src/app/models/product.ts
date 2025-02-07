import { Puja } from "./puja";

export interface Product {
    id: number;
    name: string;
    brand: string;
    releaseYear: number;
    description: string;
    photo: string;
    pujas: Puja[];
}
