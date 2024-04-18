import styled from "styled-components";
export const MsgList = styled.FlatList`
    width: 90%;
    gap: 10px;
    flex: 0.9;
    top: 20px;
`

export const MsgBody = styled.View`
    width: 40%;
    border-radius: 10px;
    padding: 15px;
    background-color: #f3f3f3;
    align-self: ${props => props.lado == "esquerdo" ? "flex-start" : "flex-end"}
`

export const MsgText = styled.Text`
    font-size: 14px;
`


