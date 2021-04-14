import { ISktSystem } from "@/types/skt_system";
import axios from "axios";

export default class SystemService{
    // API_URL = process.env.VUE_APP_API_URL;
    url = "https://localhost:44343/api"

    public async getStkSystem(): Promise<ISktSystem[]>{
        let result: any = await axios.get(`${this.url}/st_stksystem/`)
        return result.data
    }

    public async addCustomer(newSktSystem: ISktSystem): Promise<ISktSystem>{
        let result: any =  await axios.post(`${this.url}/st_stksystem/`, newSktSystem);
        return result.data;
    };
}