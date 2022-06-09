import './App.css';
import React, { useEffect, useState } from "react";
import Unity, { UnityContext } from "react-unity-webgl";
import 'bootstrap/dist/css/bootstrap.min.css';
import { ProgressBar } from "react-bootstrap";
import Loading from './Loading.gif';
import FullScreen from './icon.png';

const unityContext = new UnityContext({
  loaderUrl: "Build/WebGL.loader.js",
  dataUrl: "Build/WebGL.data",
  frameworkUrl: "Build/WebGL.framework.js",
  codeUrl: "Build/WebGL.wasm",
})

export default function App() {
  const [progression, setProgression] = useState(0);
  const [LoadingStyle, setLoadingStyle] = useState({ display: 'block' });
  const [UnityStyle, setUnityStyle] = useState({ display: 'none' });

  useEffect(function () {
    unityContext.on("progress", function (progression) {
      setProgression(Math.floor(progression * 10000) / 100);
      if (progression === 1) {
        setLoadingStyle({ display: 'none' })
        setUnityStyle({ display: 'block' })
      }
    });
  }, [progression]);

  function LoadingComponent() {
    return (
      <div id="asdf">
        <div>
          <img src={Loading}></img>
          <ProgressBar id="progressbar" striped variant="warning" animated now={progression} label={`${progression}%`} />
        </div>
      </div>
    );
  };

  return (
    <div>
      <div style={LoadingStyle}>
        <LoadingComponent/>
      </div>
      <div style={UnityStyle}>
        <UnityComponent />
      </div>
    </div>
  );
};

function UnityComponent() {
  function handleOnClickFullscreen() {
    unityContext.setFullscreen(true);
  }

  return (
    <div id="asdf">
      <div id="unity">
        <Unity
          style={{
            width: '80vw',
            height: '45vw',
            maxWidth: '142.2vh',
            maxHeight: '80vh'
          }}
          unityContext={unityContext} />

        <div id="fullscreen">
          <img id="fscr" src={FullScreen} onClick={handleOnClickFullscreen} style={{
            width: '30px',
            height: '30px',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center'
          }}></img>
        </div>
        
      </div>
    </div>
  );
};

