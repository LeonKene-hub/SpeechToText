import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import { HeaderMsn } from './src/components/header/Header';
import { MsgList } from './src/components/msn/Style';
import { InputMsg } from './src/components/input/input';
import { useState } from 'react';
import { MsgBallon } from './src/components/msn/msg';
import api from './src/services/Service';
import axios from 'axios';

export default function App() {
    const [dados,setdados]= useState([
          {id:1, texto:"a", lado:"esquerdo"},
          {id:2, texto:"b", lado:""},
          {id:3, texto:"c", lado:"esquerdo"},
    ])

    const [value, setValue]= useState("")

    async function TextToSpeech(){
      try {
        const form = new FormData()

        // form.append("Arquivo", {
        //   name: "texto",
        //   type: "string"
        // })
        // //form.append("",texto)

        const response = await axios.post(`http://192.168.21.126:5112/api/texttospeech`, {"texto":value} )
        console.log(response.status);
      } catch (error) {
        console.log("Erro na requisição de texto para fala:" + error);
      }
    }

  return (
    <View style={{flex:1,alignItems:"center"}}>
      <HeaderMsn/>

      <MsgList
        data={dados}
        keyExtrator={(item) => item.id}
        renderItem = {({item}) => <MsgBallon texto={item.texto} lado={item.lado}/>}
      />

      <InputMsg
        value = {value}
        tipo={value != "" ? "Digitar" : "audio"}
        onChangeText={(newValue) => setValue(newValue)}
        onPress={() => {TextToSpeech()}}
      />
    </View>
  );
}


