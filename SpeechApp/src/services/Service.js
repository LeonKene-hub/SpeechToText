import axios from "axios";

const apiPort = "5112";
const ip = "192.168.21.126"
const apiUrlLocal = `http://${ip}:${apiPort}/api`;

const api = axios.create({
    baseUrl: apiUrlLocal
});

export default api;