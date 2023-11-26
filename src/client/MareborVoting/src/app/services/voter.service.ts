import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Voter } from "../models/voter.model";
import { Observable } from "rxjs";
import { AppConfigService } from "./app-config.service";
import { ApiService } from "./api.service";
import { CommandResult } from "../models/command-result.model";

@Injectable({
    providedIn: 'root'
})
export class VoterService {

    constructor(private httpClient: HttpClient, private appConfigService: AppConfigService, private apiService: ApiService) { }

    getVoters(): Observable<Voter[]> {
        return this.httpClient.get<Voter[]>(`${this.appConfigService.apiUrl}/voters`);
    }

    addVoter(name: string): Observable<CommandResult> {
        return this.apiService.sendCommand(`${this.appConfigService.apiUrl}/voters/add`, { name });
    }
}