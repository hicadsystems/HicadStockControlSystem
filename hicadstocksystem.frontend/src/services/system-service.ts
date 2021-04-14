import { ISktSystem } from "@/types/skt_system";
import axios from "axios";

export default class SystemService{
    API_URL = process.env.VUE_APP_API_URL;

    public async getStkSystem(): Promise<ISktSystem[]>{
        let result: any = await axios.get(`${this.API_URL}/st_stksystem/`)
        return result.data
    }
}