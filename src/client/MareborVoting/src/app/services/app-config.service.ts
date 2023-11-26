import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class AppConfigService {
    get apiUrl(): string {
        return 'https://localhost:7188'; // static value for simplicity
    }
}